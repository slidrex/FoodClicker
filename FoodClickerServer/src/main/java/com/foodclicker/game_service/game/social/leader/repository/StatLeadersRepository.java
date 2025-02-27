package com.foodclicker.game_service.game.social.leader.repository;

import com.foodclicker.game_service.game.shop.transactions.entity.PlayerStats;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface StatLeadersRepository extends CrudRepository<PlayerStats, Long> {
    List<PlayerStats> findTop10ByOrderByMoneyDesc();
}
