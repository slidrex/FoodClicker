package com.foodclicker.game_service.game.social.player_profile.controller;

import com.foodclicker.game_service.food_id.identity_service.exception.UnknownUserException;
import com.foodclicker.game_service.game.social.player_profile.service.PlayerProfileService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("api/v0/game/social/profile/")
public class PlayerProfileContoller {
    @Autowired
    private PlayerProfileService playerProfileService;
    @GetMapping("get_my_profile")
    private ResponseEntity<?> getIncomingProfile() throws UnknownUserException {
        return ResponseEntity.ok(playerProfileService.getIncomingUserProfile());
    }
}
