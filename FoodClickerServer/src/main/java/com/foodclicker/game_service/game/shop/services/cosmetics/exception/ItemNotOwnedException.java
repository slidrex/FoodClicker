package com.foodclicker.game_service.game.shop.services.cosmetics.exception;

public class ItemNotOwnedException extends Exception {
    public ItemNotOwnedException() {
        super("Item not owned");
    }
}
