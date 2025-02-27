package com.foodclicker.game_service.game.shop.transactions.exception;

import com.foodclicker.game_service.food_id.identity_service.dto.StatusResponse;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;

@ControllerAdvice
public class ShopExceptionHandler {
    @ExceptionHandler({NotEnoughMoneyException.class})
    private ResponseEntity<?> shopExceptionCatcher(Exception e) {
        return ResponseEntity.badRequest().body( new StatusResponse(e.getMessage()) );
    }
}
