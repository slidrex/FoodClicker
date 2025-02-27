package com.foodclicker.game_service.game.shop.services.cosmetics.exception;

public class DuplicateGroupEquipmentViolation extends Exception{
    public DuplicateGroupEquipmentViolation(int groupId, int oldItemIndex, int newItemIndex) {
        super("Duplicate equipment found while resolving group " + groupId + " (old equip " + oldItemIndex + ", new equip " + newItemIndex);
    }
}
