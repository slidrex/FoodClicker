package com.foodclicker.game_service.food_id.identity_service.entity;

import com.foodclicker.game_service.game.shop.services.cosmetics.entity.PlayerCosmeticsEntity;
import com.foodclicker.game_service.game.shop.services.cosmetics.entity.PlayerEquippedCosmeticsEntity;
import com.foodclicker.game_service.game.shop.services.production.entity.PlayerProductionEntity;
import com.foodclicker.game_service.game.shop.transactions.entity.PlayerStats;
import com.foodclicker.game_service.game.social.player_profile.entity.PlayerProfileEntity;
import jakarta.persistence.*;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;

import java.util.Collection;
import java.util.List;

@Entity
@Table(name = "user")
@NoArgsConstructor
@Getter
@Setter
public class UserEntity implements UserDetails {
    private String email;
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;
    @OneToOne(mappedBy = "user")
    private AuthToken token;
    @OneToOne(mappedBy = "user")
    private PlayerStats playerStats;
    @OneToMany(mappedBy = "user")
    private List<PlayerCosmeticsEntity> cosmeticsObjects;
    @OneToMany(mappedBy = "user", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<PlayerProductionEntity> userProductions;
    @OneToMany(mappedBy = "user", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<PlayerCosmeticsEntity> playerCosmetics;
    @OneToMany(mappedBy = "user")
    private List<PlayerEquippedCosmeticsEntity> equippedCosmetics;
    @OneToOne(mappedBy = "user")
    private PlayerProfileEntity profile;
    public UserEntity(String email) {
        this.email = email;
    }

    @Override
    public Collection<? extends GrantedAuthority> getAuthorities() {
        return null;
    }

    @Override
    public String getPassword() {
        return getEmail();
    }

    @Override
    public String getUsername() {
        return getEmail();
    }

    @Override
    public boolean isAccountNonExpired() {
        return true;
    }

    @Override
    public boolean isAccountNonLocked() {
        return true;
    }

    @Override
    public boolean isCredentialsNonExpired() {
        return true;
    }

    @Override
    public boolean isEnabled() {
        return true;
    }

}
