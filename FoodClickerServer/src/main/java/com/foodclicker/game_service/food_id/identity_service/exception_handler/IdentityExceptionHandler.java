package com.foodclicker.game_service.food_id.identity_service.exception_handler;

import com.foodclicker.game_service.food_id.identity_service.dto.StatusResponse;
import com.foodclicker.game_service.food_id.identity_service.exception.UnknownUserException;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;

@ControllerAdvice
public class IdentityExceptionHandler {
    @ExceptionHandler({UnknownUserException.class})
    private ResponseEntity<?> identityExceptionCatcher(Exception e) {
        return ResponseEntity.badRequest().body( new StatusResponse(e.getMessage()));
    }
}
