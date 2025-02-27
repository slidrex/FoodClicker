package com.foodclicker.game_service.game.social.player_profile.entity;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.foodclicker.game_service.food_id.identity_service.entity.UserEntity;
import jakarta.persistence.*;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.ZoneOffset;
import java.util.Date;
import java.time.LocalDate;

@Entity
@Getter
@Setter
@NoArgsConstructor
public class PlayerProfileEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;
    @JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy.MM.dd")
    private Date registrationDate;
    @OneToOne
    @JoinColumn(name = "user_id")
    private UserEntity user;
    public PlayerProfileEntity(UserEntity user) {
        this.registrationDate = Date.from(LocalDate.now().atStartOfDay().toInstant(ZoneOffset.UTC));
        this.user = user;
    }
}
