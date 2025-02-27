package com.foodclicker.game_service.game.shop.services.cosmetics.exception;

public class ItemAlreadyEquippedException extends Exception{
    public ItemAlreadyEquippedException() {
        super("Item already equipped");
    }
}
