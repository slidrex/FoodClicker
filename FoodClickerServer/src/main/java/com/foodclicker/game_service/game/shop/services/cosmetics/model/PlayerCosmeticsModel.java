package com.foodclicker.game_service.game.shop.services.cosmetics.model;

import com.foodclicker.game_service.game.shop.services.cosmetics.document.CosmeticsDocument;
import com.foodclicker.game_service.game.shop.services.cosmetics.document.CosmeticsGroupElement;
import com.foodclicker.game_service.game.shop.services.cosmetics.entity.PlayerCosmeticsEntity;
import com.foodclicker.game_service.game.shop.services.cosmetics.entity.PlayerEquippedCosmeticsEntity;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
@AllArgsConstructor
public class PlayerCosmeticsModel {
    private int groupId;
    private int itemId;
    public PlayerCosmeticsModel(PlayerCosmeticsEntity entity) {
        this.groupId = entity.getGroupId();
        this.itemId = entity.getItemId();
    }
    public PlayerCosmeticsModel(PlayerEquippedCosmeticsEntity entity) {
        var cosmetics = entity.getCosmetics();
        this.groupId = cosmetics.getGroupId();
        this.itemId = cosmetics.getItemId();
    }
}
