package com.foodclicker.game_service.game.social.leader.controller;

import com.foodclicker.game_service.game.social.leader.service.LeaderboardService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("api/v0/game/social/leader/")
public class LeaderboardController {
    @Autowired
    private LeaderboardService leaderService;
    @GetMapping("get_gold_leaders")
    private ResponseEntity<?> getGoldLeaders() {
        return ResponseEntity.ok(leaderService.getMoneyLeaders());
    }
}
