package com.foodclicker.game_service.game.shop.services.production.dto;

import com.foodclicker.game_service.game.shop.services.production.model.ProductionModel;
import com.foodclicker.game_service.game.shop.transactions.entity.PlayerStats;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

import java.util.List;

@Getter
@Setter
@AllArgsConstructor
public class PlayerProductionResponse {
    private Integer userMoney;
    private int gps;
    private Integer gpc;
    List<ProductionModel> productionModels;
    public PlayerProductionResponse(PlayerStats stats, List<ProductionModel> models) {
        this.productionModels = models;
        userMoney = stats.getMoney();
        gps = stats.getGps();
        gpc = stats.getGpc();
    }
}
