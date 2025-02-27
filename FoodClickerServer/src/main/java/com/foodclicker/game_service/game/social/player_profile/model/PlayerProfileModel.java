package com.foodclicker.game_service.game.social.player_profile.model;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

import java.text.SimpleDateFormat;
import java.util.Date;

@Getter
@Setter
public class PlayerProfileModel {
    private String registrationDate;
    private String email;
    private Long userId;
    public PlayerProfileModel(Long userId, String email, Date registrationDate) {
        this.userId = userId;
        this.email = email;
        this.registrationDate = new SimpleDateFormat("yyyy.MM.dd").format(registrationDate);
    }
}
