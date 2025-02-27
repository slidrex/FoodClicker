package com.foodclicker.game_service.food_id.identity_service.exception;

public class UnknownUserException extends Exception{
    public UnknownUserException() {
        super("Unknown user");
    }
}
