package com.foodclicker.game_service.game.social.leader.service;

import com.foodclicker.game_service.game.social.leader.model.MoneyLeaderModel;
import com.foodclicker.game_service.game.social.leader.repository.StatLeadersRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class LeaderboardService {
    @Autowired
    private StatLeadersRepository statLeadersRepository;
    public List<MoneyLeaderModel> getMoneyLeaders() {
        var leaders = statLeadersRepository.findTop10ByOrderByMoneyDesc();
        List<MoneyLeaderModel> leaderModels = new ArrayList<>();
        for (var leaderEntity:
             leaders) {
            leaderModels.add(new MoneyLeaderModel(leaderEntity));
        }
        return leaderModels;
    }
}
