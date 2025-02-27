package com.foodclicker.game_service.game.reset.ascention.exception_handler;

import com.foodclicker.game_service.food_id.identity_service.dto.StatusResponse;
import com.foodclicker.game_service.game.reset.ascention.exception.NotEnoughPrestigeLevel;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;

public class AscensionExceptionController {
    @ExceptionHandler({NotEnoughPrestigeLevel.class})
    private ResponseEntity<?> ascensionExceptionHandler(Exception e) {
        return ResponseEntity.badRequest().body(new StatusResponse(e.getMessage()));
    }
}
