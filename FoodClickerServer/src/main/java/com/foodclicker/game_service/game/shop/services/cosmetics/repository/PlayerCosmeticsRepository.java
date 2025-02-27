package com.foodclicker.game_service.game.shop.services.cosmetics.repository;

import com.foodclicker.game_service.game.shop.services.cosmetics.entity.PlayerCosmeticsEntity;
import org.springframework.data.repository.CrudRepository;

public interface PlayerCosmeticsRepository extends CrudRepository<PlayerCosmeticsEntity, Long> {
}
