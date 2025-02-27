package com.foodclicker.game_service.food_id.identity_service.repository;

import com.foodclicker.game_service.food_id.identity_service.entity.AuthToken;
import org.springframework.data.repository.CrudRepository;

public interface TokenRepository extends CrudRepository<AuthToken, Long> {
}
