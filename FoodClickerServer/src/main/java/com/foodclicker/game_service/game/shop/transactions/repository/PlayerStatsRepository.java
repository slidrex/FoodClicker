package com.foodclicker.game_service.game.shop.transactions.repository;

import com.foodclicker.game_service.game.shop.transactions.entity.PlayerStats;
import org.springframework.data.repository.CrudRepository;

public interface PlayerStatsRepository extends CrudRepository<PlayerStats, Long> {
}
