package com.foodclicker.game_service.game.shop.services.cosmetics.dto;

import com.foodclicker.game_service.game.shop.services.cosmetics.model.PlayerCosmeticsModel;
import com.foodclicker.game_service.game.shop.services.production.dto.PlayerStatsResponse;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
@AllArgsConstructor
public class BuyCosmeticsResponse {
    private PlayerCosmeticsModel model;
    private PlayerStatsResponse stats;
}