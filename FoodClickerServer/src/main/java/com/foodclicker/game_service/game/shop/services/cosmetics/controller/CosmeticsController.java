package com.foodclicker.game_service.game.shop.services.cosmetics.controller;

import com.foodclicker.game_service.food_id.identity_service.exception.UnknownUserException;
import com.foodclicker.game_service.game.reset.ascention.exception.NotEnoughPrestigeLevel;
import com.foodclicker.game_service.game.shop.services.cosmetics.dto.BuyCosmeticsRequest;
import com.foodclicker.game_service.game.shop.services.cosmetics.dto.EquipCosmeticsRequest;
import com.foodclicker.game_service.game.shop.services.cosmetics.exception.*;
import com.foodclicker.game_service.game.shop.services.cosmetics.service.CosmeticsService;
import com.foodclicker.game_service.game.shop.transactions.exception.NotEnoughMoneyException;
import lombok.Getter;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("api/v0/game/shop/cosmetics/")
public class CosmeticsController {
    @Autowired
    private CosmeticsService cosmeticsService;
    @GetMapping("get_player_cosmetics/{group_id}")
    private ResponseEntity<?> getPlayerCosmetics(@PathVariable(name = "group_id") int groupId) throws UnknownUserException {
        return ResponseEntity.ok(cosmeticsService.getPlayerGroupCosmetics(groupId));
    }
    @PostMapping("buy_cosmetics")
    private ResponseEntity<?> buyCosmetics(@RequestBody BuyCosmeticsRequest request) throws ItemAlreadyOwnedException, NotEnoughMoneyException, UnknownUserException, UnknownCosmeticsTemplateException, NotEnoughPrestigeLevel {
        return ResponseEntity.ok(cosmeticsService.buyCosmetics(request));
    }
    @PostMapping("equip_cosmetics")
    private ResponseEntity<?> equipCosmetics(@RequestBody EquipCosmeticsRequest request) throws UnknownUserException, ItemNotOwnedException, ItemAlreadyEquippedException {
        return ResponseEntity.ok(cosmeticsService.equipCosmetics(request));
    }
    @GetMapping("get_all_items")
    private ResponseEntity<?> getAllItems() throws UnknownCosmeticsTemplateException {
        return ResponseEntity.ok(cosmeticsService.getAllCosmetics());
    }
    @GetMapping("get_all_player_cosmetics")
    private ResponseEntity<?> getAllPlayerCosmetics() throws UnknownUserException, DuplicateGroupEquipmentViolation {
        return ResponseEntity.ok(cosmeticsService.getAllPlayerCosmetics());
    }
    @GetMapping("get_ready_cosmetics/{group_id}")
    private ResponseEntity<?> getPlayerCosmeticsView(@PathVariable(name = "group_id") Integer groupId) throws UnknownUserException, UnknownCosmeticsTemplateException {
        return ResponseEntity.ok(cosmeticsService.getPlayerReadyItems(groupId));
    }
    @GetMapping("get_player_equipped_cosmetics")
    private ResponseEntity<?> getPlayerEquippedCosmetics() throws UnknownUserException {
        return ResponseEntity.ok(cosmeticsService.getPlayerEquippedCosmetics());
    }
}
