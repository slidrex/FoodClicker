package com.foodclicker.game_service.food_id.email.dto;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

@Builder
@Getter
@Setter
@AllArgsConstructor
public class MailSendResponse {
    private String status;
}
