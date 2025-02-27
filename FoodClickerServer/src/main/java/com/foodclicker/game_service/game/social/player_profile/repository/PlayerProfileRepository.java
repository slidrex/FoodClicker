package com.foodclicker.game_service.game.social.player_profile.repository;

import com.foodclicker.game_service.game.social.player_profile.entity.PlayerProfileEntity;
import org.springframework.data.repository.CrudRepository;

public interface PlayerProfileRepository extends CrudRepository<PlayerProfileEntity, Long> {
}
