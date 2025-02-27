package com.foodclicker.game_service.game.shop.transactions.service;

import com.foodclicker.game_service.food_id.identity_service.repository.UserRepository;
import com.foodclicker.game_service.game.shop.transactions.dto.PlayerMoneyResponse;
import com.foodclicker.game_service.game.shop.transactions.repository.PlayerStatsRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

@Service
public class CurrencyService {
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private PlayerStatsRepository playerStatsRepository;
    public PlayerMoneyResponse completeCycle() {
        var user = userRepository.findByEmail(SecurityContextHolder.getContext().getAuthentication().getName()).orElseThrow(() -> new UsernameNotFoundException("Unknown user"));
        var playerStats = user.getPlayerStats();
        playerStats.setMoney(playerStats.getMoney() + playerStats.getGps());
        playerStatsRepository.save(playerStats);
        return new PlayerMoneyResponse(playerStats.getMoney());
    }
    public PlayerMoneyResponse completeClick() {
        var user = userRepository.findByEmail(SecurityContextHolder.getContext().getAuthentication().getName()).orElseThrow(() -> new UsernameNotFoundException("Unknown user"));
        var playerStats = user.getPlayerStats();
        playerStats.setMoney(playerStats.getMoney() + playerStats.getGpc());
        playerStatsRepository.save(playerStats);
        return new PlayerMoneyResponse(playerStats.getMoney());
    }
}
