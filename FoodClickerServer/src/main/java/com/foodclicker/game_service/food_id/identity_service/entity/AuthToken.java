package com.foodclicker.game_service.food_id.identity_service.entity;

import jakarta.persistence.*;

@Entity
@Table(name = "auth_token")
public class AuthToken {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;
    private String signature;
    @OneToOne
    @JoinColumn(name = "user_id")
    private UserEntity user;

    public AuthToken() {
    }

    public AuthToken(String signature, UserEntity user) {
        this.signature = signature;
        this.user = user;
    }

    public String getSignature() {
        return signature;
    }

    public void setSignature(String signature) {
        this.signature = signature;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public UserEntity getUser() {
        return user;
    }

    public void setUser(UserEntity user) {
        this.user = user;
    }
}