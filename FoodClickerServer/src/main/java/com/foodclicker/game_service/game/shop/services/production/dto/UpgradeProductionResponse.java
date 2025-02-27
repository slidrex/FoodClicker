package com.foodclicker.game_service.game.shop.services.production.dto;

import com.foodclicker.game_service.game.shop.services.production.model.ProductionModel;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@AllArgsConstructor
@Getter
@Setter
public class UpgradeProductionResponse {
    private PlayerStatsResponse stats;
    private ProductionModel model;
}
