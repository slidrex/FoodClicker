package com.foodclicker.game_service.game.shop.services.cosmetics.exception;

public class ItemAlreadyOwnedException extends Exception{
    public ItemAlreadyOwnedException() {
        super("Item already owned");
    }
}
