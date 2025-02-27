package com.foodclicker.game_service.food_id.identity_service.exception;

public class InvalidCredentialsException extends Exception{

    public InvalidCredentialsException() {
        super("Bad credentials");
    }
}
