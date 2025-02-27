package com.foodclicker.game_service.game.shop.services.cosmetics.dto;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class EquipCosmeticsRequest {
    private int groupId;
    private int itemId;
}
