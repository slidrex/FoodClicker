package com.foodclicker.game_service.food_id.identity_service.controller;

import com.foodclicker.game_service.food_id.identity_service.dto.LoginRequest;
import com.foodclicker.game_service.food_id.identity_service.dto.StatusResponse;
import com.foodclicker.game_service.food_id.identity_service.exception.InvalidCodeOrSessionExpiredException;
import com.foodclicker.game_service.food_id.identity_service.exception.InvalidCredentialsException;
import com.foodclicker.game_service.food_id.identity_service.service.IdentityService;
import io.swagger.v3.oas.annotations.media.Schema;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@Schema(name = "food-id-auth")
@RequestMapping("api/v0/foodid/auth/")
public class IdentityController {
    @Autowired
    private IdentityService identityService;
    @PostMapping("authenticate")
    private ResponseEntity<?> authenticate(@RequestBody LoginRequest request) throws InvalidCodeOrSessionExpiredException, InvalidCredentialsException {
        return ResponseEntity.ok(identityService.authenticate(request));
    }
    @ExceptionHandler({InvalidCodeOrSessionExpiredException.class, InvalidCredentialsException.class})
    private ResponseEntity<?> identityExceptionCatcher(Exception exception) {
        return ResponseEntity.badRequest().body(new StatusResponse(exception.getMessage()));
    }
}
