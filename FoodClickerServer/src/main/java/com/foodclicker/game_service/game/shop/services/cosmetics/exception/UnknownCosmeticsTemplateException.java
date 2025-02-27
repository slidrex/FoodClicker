package com.foodclicker.game_service.game.shop.services.cosmetics.exception;

public class UnknownCosmeticsTemplateException extends Exception{
    public UnknownCosmeticsTemplateException() {
        super("Unknown cosmetics or group id");
    }
}
