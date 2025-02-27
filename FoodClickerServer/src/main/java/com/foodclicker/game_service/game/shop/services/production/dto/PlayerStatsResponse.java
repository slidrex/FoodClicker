package com.foodclicker.game_service.game.shop.services.production.dto;

import com.foodclicker.game_service.game.shop.transactions.entity.PlayerStats;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@AllArgsConstructor
@Getter
@Setter
public class PlayerStatsResponse {
    private int userMoney;
    private int gps;
    private int gpc;
    private int prestigeLevel;
    public PlayerStatsResponse(PlayerStats stats) {
        this.userMoney = stats.getMoney();
        this.gpc = stats.getGpc();
        this.prestigeLevel = stats.getPrestigeLevel();
        this.gps = stats.getGps();
    }
}
