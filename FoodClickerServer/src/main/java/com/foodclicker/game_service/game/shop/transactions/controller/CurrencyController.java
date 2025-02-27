package com.foodclicker.game_service.game.shop.transactions.controller;

import com.foodclicker.game_service.game.shop.transactions.service.CurrencyService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PatchMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("api/v0/game/currency/")
public class CurrencyController {
    @Autowired
    private CurrencyService currencyService;
    @PatchMapping("complete_cycle")
    private ResponseEntity<?> completeCycle() {
        return ResponseEntity.ok(currencyService.completeCycle());
    }
    @PatchMapping("perform_click")
    private ResponseEntity<?> performClick() {
        return ResponseEntity.ok(currencyService.completeClick());
    }
}
