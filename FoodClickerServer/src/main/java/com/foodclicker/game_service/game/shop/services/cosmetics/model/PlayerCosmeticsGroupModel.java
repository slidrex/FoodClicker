package com.foodclicker.game_service.game.shop.services.cosmetics.model;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

import java.util.List;

@AllArgsConstructor
@Setter
@Getter
public class PlayerCosmeticsGroupModel {
    private int equippedItemId;
    private List<CosmeticsGroupedItemModel> items; 
}
