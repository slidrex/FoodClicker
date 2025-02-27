package com.foodclicker.game_service.game.reset.ascention.service;

import com.foodclicker.game_service.food_id.identity_service.entity.UserEntity;
import com.foodclicker.game_service.food_id.identity_service.exception.UnknownUserException;
import com.foodclicker.game_service.food_id.identity_service.repository.UserRepository;
import com.foodclicker.game_service.food_id.identity_service.util.IdentityUtil;
import com.foodclicker.game_service.game.reset.ascention.dto.PrestigeLevelResponse;
import com.foodclicker.game_service.game.reset.ascention.dto.PrestigePriceResponse;
import com.foodclicker.game_service.game.shop.services.cosmetics.util.CosmeticsUtil;
import com.foodclicker.game_service.game.shop.services.production.dto.PlayerStatsResponse;
import com.foodclicker.game_service.game.shop.services.production.exception.UnknownProductionTemplateId;
import com.foodclicker.game_service.game.shop.services.production.repository.PlayerProductionRepository;
import com.foodclicker.game_service.game.shop.services.production.service.ProductionShopService;
import com.foodclicker.game_service.game.shop.transactions.entity.PlayerStats;
import com.foodclicker.game_service.game.shop.transactions.exception.NotEnoughMoneyException;
import com.foodclicker.game_service.game.shop.transactions.repository.PlayerStatsRepository;
import com.foodclicker.game_service.game.shop.transactions.service.ShopService;
import com.foodclicker.game_service.game.shop.transactions.util.TransactionService;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

@Service
public class AscentionService {
    @Value("${application.ascention.prestige-level-money-treshold}")
    private Long prestigeTreshold;
    @Autowired
    private ProductionShopService productionShopService;
    @Autowired
    private PlayerProductionRepository playerProductionRepository;
    @Autowired
    private IdentityUtil identityUtil;
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private TransactionService transactionService;
    @Autowired
    private ProductionShopService shopService;
    @Autowired
    private CosmeticsUtil cosmeticsUtil;
    @Transactional
    public PlayerStatsResponse makePrestige() throws UnknownUserException, NotEnoughMoneyException, UnknownProductionTemplateId {
        var user = identityUtil.getIncomingUser();
        if(user.getPlayerStats().getMoney() < prestigeTreshold) throw new NotEnoughMoneyException();
        
        productionShopService.deletePlayerProductions();
        
        transactionService.prestigeAccount();
        cosmeticsUtil.prestigePlayerCosmetics();
        
        return productionShopService.getPlayerStats();
    }
    public PrestigeLevelResponse getPrestigeLevel() throws UnknownUserException {
        var user = identityUtil.getIncomingUser();
        return new PrestigeLevelResponse(user.getPlayerStats().getPrestigeLevel());
    }
    public PrestigePriceResponse getAscentionPrice() {
        return new PrestigePriceResponse(prestigeTreshold);
    }
}
