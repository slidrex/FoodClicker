package com.foodclicker.game_service.game.reset.ascention.controller;

import com.foodclicker.game_service.food_id.identity_service.exception.UnknownUserException;
import com.foodclicker.game_service.game.reset.ascention.service.AscentionService;
import com.foodclicker.game_service.game.shop.services.production.exception.UnknownProductionTemplateId;
import com.foodclicker.game_service.game.shop.transactions.exception.NotEnoughMoneyException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PatchMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("api/v0/game/ascention/")
public class PlayerPrestigeController {
    @Autowired
    private AscentionService ascentionService;
    @PatchMapping("do_prestige")
    private ResponseEntity<?> makePrestige() throws NotEnoughMoneyException, UnknownUserException, UnknownProductionTemplateId {
        return ResponseEntity.ok(ascentionService.makePrestige());
    }
    @GetMapping("get_prestige_level")
    private ResponseEntity<?> getPrestige() throws UnknownUserException {
        return ResponseEntity.ok(ascentionService.getPrestigeLevel());
    }
    @GetMapping("get_ascention_price")
    private ResponseEntity<?> getAscentionPrice() {
        return ResponseEntity.ok(ascentionService.getAscentionPrice());
    }
}
