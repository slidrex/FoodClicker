package com.foodclicker.game_service.food_id.identity_service.service;

import com.foodclicker.game_service.food_id.identity_service.dto.LoginRequest;
import com.foodclicker.game_service.food_id.identity_service.dto.LoginResponse;
import com.foodclicker.game_service.food_id.identity_service.entity.AuthToken;
import com.foodclicker.game_service.food_id.identity_service.entity.UserEntity;
import com.foodclicker.game_service.food_id.identity_service.exception.InvalidCodeOrSessionExpiredException;
import com.foodclicker.game_service.food_id.identity_service.exception.InvalidCredentialsException;
import com.foodclicker.game_service.food_id.identity_service.repository.TokenRepository;
import com.foodclicker.game_service.food_id.identity_service.repository.UserRepository;
import com.foodclicker.game_service.game.shop.transactions.entity.PlayerStats;
import com.foodclicker.game_service.game.shop.transactions.repository.PlayerStatsRepository;
import com.foodclicker.game_service.game.social.player_profile.entity.PlayerProfileEntity;
import com.foodclicker.game_service.game.social.player_profile.repository.PlayerProfileRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.stereotype.Service;

import java.sql.Date;

@Service
public class IdentityService {
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private RedisTemplate redisTemplate;
    @Autowired
    private TokenRepository tokenRepository;
    @Autowired
    private JwtService jwtService;
    @Autowired
    private PlayerStatsRepository playerStatsRepository;
    @Autowired
    private PlayerProfileRepository playerProfileRepository;
    public LoginResponse authenticate(LoginRequest request) throws InvalidCodeOrSessionExpiredException, InvalidCredentialsException {
        request.setEmail(request.getEmail().substring(0, request.getEmail().length() - 1));
        var code = redisTemplate.opsForValue().get(request.getEmail());
        int codeObj = 0;
        
        try {
            codeObj = Integer.parseInt((String)code);
        }
        catch (NumberFormatException exception)
        {
            throw new InvalidCodeOrSessionExpiredException();
        }
        
        if(request.getCode() != codeObj) throw new InvalidCodeOrSessionExpiredException();
        var user = userRepository.findByEmail(request.getEmail());
        String accessToken = jwtService.generateToken(request.getEmail(), 604800000);


        if(user.isEmpty())
        {
            var userEntity = new UserEntity(request.getEmail());
            var playerStats = new PlayerStats(userEntity, 0, 0, 1, 0);
            var authToken = new AuthToken(accessToken, userEntity);
            var profile = new PlayerProfileEntity(userEntity);

            
            userRepository.save(userEntity);
            playerProfileRepository.save(profile);
            playerStatsRepository.save(playerStats);
            tokenRepository.save(authToken);
        }
        else
        {
            user.get().getToken().setSignature(accessToken);
            userRepository.save(user.get());
        }

        redisTemplate.delete(request.getEmail());



        return new LoginResponse(accessToken);
    }
}
