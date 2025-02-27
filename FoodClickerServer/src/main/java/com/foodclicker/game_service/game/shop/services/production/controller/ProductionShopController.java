package com.foodclicker.game_service.game.shop.services.production.controller;

import com.foodclicker.game_service.food_id.identity_service.exception.UnknownUserException;
import com.foodclicker.game_service.game.shop.transactions.exception.NotEnoughMoneyException;
import com.foodclicker.game_service.game.shop.services.production.exception.UnknownProductionTemplateId;
import com.foodclicker.game_service.game.shop.services.production.service.ProductionShopService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("api/v0/game/shop/production/")
public class ProductionShopController {
    @Autowired
    private ProductionShopService productionShopService;
    @GetMapping("get_player_production")
    private ResponseEntity<?> getPlayerProduction() throws UnknownProductionTemplateId, UnknownUserException {
        return ResponseEntity.ok(productionShopService.updatePlayerProduction());
    }
    @PatchMapping("upgrade_production/{uid}")
    private ResponseEntity<?> upgradePlayerProduction(@PathVariable Integer uid) throws NotEnoughMoneyException, UnknownProductionTemplateId, UnknownUserException {
        return ResponseEntity.ok(productionShopService.upgradeProduction(uid));
    }
    @GetMapping("get_production_templates")
    private ResponseEntity<?> getProductionTemplates() {
        return ResponseEntity.ok(productionShopService.getProductionModels());
    }
}
