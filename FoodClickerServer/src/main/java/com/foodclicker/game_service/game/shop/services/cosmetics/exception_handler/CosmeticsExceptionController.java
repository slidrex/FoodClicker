package com.foodclicker.game_service.game.shop.services.cosmetics.exception_handler;

import com.foodclicker.game_service.food_id.identity_service.dto.StatusResponse;
import com.foodclicker.game_service.game.shop.services.cosmetics.exception.ItemAlreadyEquippedException;
import com.foodclicker.game_service.game.shop.services.cosmetics.exception.ItemAlreadyOwnedException;
import com.foodclicker.game_service.game.shop.services.cosmetics.exception.ItemNotOwnedException;
import com.foodclicker.game_service.game.shop.services.cosmetics.exception.UnknownCosmeticsTemplateException;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;

@ControllerAdvice
public class CosmeticsExceptionController {
    @ExceptionHandler({ItemAlreadyEquippedException.class, ItemNotOwnedException.class, UnknownCosmeticsTemplateException.class, UnknownCosmeticsTemplateException.class, ItemAlreadyOwnedException.class})
    private ResponseEntity<?> cosmeticsExceptionHandler(Exception e) {
        return ResponseEntity.badRequest().body( new StatusResponse(e.getMessage()) );
    }
}
