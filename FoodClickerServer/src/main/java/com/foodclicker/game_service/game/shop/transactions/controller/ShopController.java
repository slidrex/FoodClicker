package com.foodclicker.game_service.game.shop.transactions.controller;

import com.foodclicker.game_service.game.shop.services.production.service.ProductionShopService;
import com.foodclicker.game_service.game.shop.transactions.service.ShopService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("api/v0/game/shop/")
public class ShopController {
    @Autowired
    private ShopService shopService;
    @Autowired
    private ProductionShopService productionShopService;
    @GetMapping("get_player_stats")
    private ResponseEntity<?> getPlayerStats() {
        return ResponseEntity.ok(productionShopService.getPlayerStats());
    }
}
