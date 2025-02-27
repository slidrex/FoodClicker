package com.foodclicker.game_service.food_id.identity_service.dto;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@Setter
@Getter
@AllArgsConstructor
public class LoginResponse {
    private String accessToken;
}
