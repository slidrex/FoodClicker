package com.foodclicker.game_service.food_id.email.controller;

import com.foodclicker.game_service.food_id.email.dto.EmailCodeRequest;
import com.foodclicker.game_service.food_id.email.service.EmailService;
import io.swagger.v3.oas.annotations.media.Schema;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Random;

@RestController
@Schema(name = "food-id-email")
@RequestMapping("api/v0/foodid/email/")
public class EmailController {
    @Autowired
    private EmailService emailService;
    @PostMapping("send_confirmation_code")
    private ResponseEntity<?> sendConfirmationCode(@RequestBody EmailCodeRequest codeRequest) {
        codeRequest.setEmail(codeRequest.getEmail().substring(0, codeRequest.getEmail().length() - 1));
        var response = emailService.sendConfirmationCode(codeRequest);
        return ResponseEntity.ok(response);
    }
}
