package com.foodclicker.game_service.food_id.identity_service.exception;

public class InvalidCodeOrSessionExpiredException extends Exception{
    public InvalidCodeOrSessionExpiredException() {
        super("Invalid code or session has expired");
    }
}
