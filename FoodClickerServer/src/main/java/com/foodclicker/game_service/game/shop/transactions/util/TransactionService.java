package com.foodclicker.game_service.game.shop.transactions.util;

import com.foodclicker.game_service.food_id.identity_service.entity.UserEntity;
import com.foodclicker.game_service.food_id.identity_service.exception.UnknownUserException;
import com.foodclicker.game_service.food_id.identity_service.repository.UserRepository;
import com.foodclicker.game_service.food_id.identity_service.util.IdentityUtil;
import com.foodclicker.game_service.game.shop.services.production.dto.PlayerStatsResponse;
import com.foodclicker.game_service.game.shop.transactions.exception.NotEnoughMoneyException;
import com.foodclicker.game_service.game.shop.transactions.repository.PlayerStatsRepository;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

@Service
public class TransactionService {
    @Autowired
    private PlayerStatsRepository playerStatsRepository;
    @Autowired
    private IdentityUtil identityUtil;
    @Transactional
    public void trySpendMoney(UserEntity user, int money)  throws  NotEnoughMoneyException{
        var playerStats = user.getPlayerStats();
        if(playerStats.getMoney() >= money) {
            playerStats.setMoney(playerStats.getMoney() - money);
            playerStatsRepository.save(playerStats);
        } else throw new NotEnoughMoneyException();
    }
    @Transactional
    public void prestigeAccount() throws UnknownUserException {
        var user = identityUtil.getIncomingUser();
        var stats = user.getPlayerStats();
        stats.setMoney(0);
        stats.setPrestigeLevel(stats.getPrestigeLevel() + 1);
        playerStatsRepository.save(stats);
    }
}
