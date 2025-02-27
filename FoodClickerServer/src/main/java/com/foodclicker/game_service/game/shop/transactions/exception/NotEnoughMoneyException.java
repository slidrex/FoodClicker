package com.foodclicker.game_service.game.shop.transactions.exception;

public class NotEnoughMoneyException extends Exception{
    public NotEnoughMoneyException() {
        super("Not enough money");
    }
}
