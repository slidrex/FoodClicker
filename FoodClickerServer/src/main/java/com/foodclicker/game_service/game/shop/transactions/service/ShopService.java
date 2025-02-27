package com.foodclicker.game_service.game.shop.transactions.service;

import com.foodclicker.game_service.food_id.identity_service.repository.UserRepository;
import com.foodclicker.game_service.game.shop.services.production.dto.PlayerStatsResponse;
import com.foodclicker.game_service.game.shop.transactions.dto.PlayerMoneyResponse;
import com.foodclicker.game_service.game.shop.transactions.repository.PlayerStatsRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

@Service
public class ShopService {
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private PlayerStatsRepository statsRepository;
    public PlayerMoneyResponse getPlayerMoney() {
        var user = userRepository.findByEmail( SecurityContextHolder.getContext().getAuthentication().getName()).orElseThrow(() -> new UsernameNotFoundException("Unknown user"));
        
        return new PlayerMoneyResponse(user.getPlayerStats().getMoney());
    }
}
