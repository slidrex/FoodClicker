package com.foodclicker.game_service.game.shop.services.production.service;

import com.foodclicker.game_service.food_id.identity_service.entity.UserEntity;
import com.foodclicker.game_service.food_id.identity_service.exception.UnknownUserException;
import com.foodclicker.game_service.food_id.identity_service.repository.UserRepository;
import com.foodclicker.game_service.food_id.identity_service.util.IdentityUtil;
import com.foodclicker.game_service.game.shop.services.production.dto.PlayerStatsResponse;
import com.foodclicker.game_service.game.shop.services.production.dto.UpgradeProductionResponse;
import com.foodclicker.game_service.game.shop.services.production.model.ProductionDocumentModel;
import com.foodclicker.game_service.game.shop.transactions.exception.NotEnoughMoneyException;
import com.foodclicker.game_service.game.shop.services.production.dto.PlayerProductionResponse;
import com.foodclicker.game_service.game.shop.services.production.entity.PlayerProductionEntity;
import com.foodclicker.game_service.game.shop.services.production.exception.UnknownProductionTemplateId;
import com.foodclicker.game_service.game.shop.services.production.model.ProductionModel;
import com.foodclicker.game_service.game.shop.services.production.repository.PlayerProductionRepository;
import com.foodclicker.game_service.game.shop.services.production.repository.ProductionDocumentRepository;
import com.foodclicker.game_service.game.shop.services.production.util.ProductionUtil;
import com.foodclicker.game_service.game.shop.transactions.repository.PlayerStatsRepository;
import com.foodclicker.game_service.game.shop.transactions.util.TransactionService;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class ProductionShopService {
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private PlayerProductionRepository playerProductionRepository;
    @Autowired
    private ProductionDocumentRepository productionDocumentRepository;
    @Autowired
    private ProductionUtil productionUtil;
    @Autowired
    private PlayerStatsRepository playerStatsRepository;
    @Autowired
    private TransactionService transactionService;
    @Autowired
    private IdentityUtil identityUtil;
    public UpgradeProductionResponse upgradeProduction(int productionUid) throws UnknownProductionTemplateId, NotEnoughMoneyException, UnknownUserException {
        var user = identityUtil.getIncomingUser();
        var template = productionDocumentRepository.getByUid(productionUid).orElseThrow(UnknownProductionTemplateId::new);
        
        var prodEntity = getPlayerProductionEntity(user, productionUid);
        
        boolean hasProduction = (prodEntity != null);
        
        int price, newLevel;
        
        if (!hasProduction) {
            price = template.getBasePrice();
            newLevel = 0;
        } else {
            newLevel = prodEntity.getLevel() + 1;
            price = productionUtil.getProductionPrice(template.getBasePrice(), prodEntity.getLevel() + 1);
        }
        
        transactionService.trySpendMoney(user, price);
        
        if(hasProduction) {prodEntity.setLevel(newLevel); playerProductionRepository.save(prodEntity);}
        else{ prodEntity = new PlayerProductionEntity(template.getUid(), newLevel, user); user.getUserProductions().add(prodEntity); }
        
        
        updatePlayerProduction();
        
        var playerStats = 
                new PlayerStatsResponse( prodEntity.getUser().getPlayerStats() );
        var productionModel = 
                new ProductionModel(template, newLevel, productionUtil.getProductionPrice(template.getBasePrice(), newLevel + 1));
        
        return new UpgradeProductionResponse(playerStats, productionModel);
    }
    private PlayerProductionEntity getPlayerProductionEntity(UserEntity user, int productionUid) {
        return
                user.getUserProductions().stream()
                        .filter(x -> x.getProductionUID() == productionUid)
                        .findFirst().orElse(null);
    }
    @Transactional(Transactional.TxType.REQUIRES_NEW)
    public List<ProductionModel> updatePlayerProduction() throws UnknownProductionTemplateId, UnknownUserException {
        var user = identityUtil.getIncomingUser();
        var playerStats = user.getPlayerStats();
        var playerProductions = user.getUserProductions();
        
        int gpc = 1;
        int gps = 0;
        List<ProductionModel> models = new ArrayList<>();
        
        for (var prod:
                playerProductions) {
            var template = productionDocumentRepository.getByUid(prod.getProductionUID()).orElseThrow(() -> new UnknownProductionTemplateId());
            var currentModel = new ProductionModel(template, prod.getLevel(), productionUtil.getProductionPrice(template.getBasePrice(), prod.getLevel() + 1));
            gpc += currentModel.getGpc();
            gps += currentModel.getGps();
            models.add(currentModel);
        }
        playerStats.setGpc(gpc);
        playerStats.setGps(gps);
        playerStatsRepository.save(playerStats);
        return models;
    }
    public PlayerStatsResponse getPlayerStats() {
        var user = userRepository.findByEmail(SecurityContextHolder.getContext().getAuthentication().getName()).orElseThrow(() -> new UsernameNotFoundException("Unknown user"));
        var playerStats = user.getPlayerStats();
        return new PlayerStatsResponse(playerStats);
    }
    public List<ProductionDocumentModel> getProductionModels() {
        var models = new ArrayList<ProductionDocumentModel>();
        var docs = productionDocumentRepository.findAll();
        for (var doc:
             docs) {
            models.add(new ProductionDocumentModel(doc));
        }
        return models;
    }
    @Transactional
    public void deletePlayerProductions() throws UnknownUserException, UnknownProductionTemplateId {
        var user = identityUtil.getIncomingUser();
        user.getUserProductions().clear();
        userRepository.save(user);
        
        updatePlayerProduction();
    }
}
