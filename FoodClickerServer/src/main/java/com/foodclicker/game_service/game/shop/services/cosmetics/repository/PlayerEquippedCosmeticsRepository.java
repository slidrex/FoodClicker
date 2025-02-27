package com.foodclicker.game_service.game.shop.services.cosmetics.repository;

import com.foodclicker.game_service.game.shop.services.cosmetics.entity.PlayerEquippedCosmeticsEntity;
import org.springframework.data.repository.CrudRepository;

public interface PlayerEquippedCosmeticsRepository extends CrudRepository<PlayerEquippedCosmeticsEntity, Long> {
}
