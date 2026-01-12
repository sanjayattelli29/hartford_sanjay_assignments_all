let board = ['', '', '', '', '', '', '', '', ''];
let currentPlayer = 'X';
let gameActive = true;
let scores = {
    X: 0,
    O: 0,
    draw: 0
};

const winningConditions = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6]
];

const cells = document.querySelectorAll('.cell');
const turnInfo = document.getElementById('turnInfo');
const gameStatus = document.getElementById('gameStatus');
const restartBtn = document.getElementById('restartBtn');
const resetScoreBtn = document.getElementById('resetScoreBtn');
const scoreX = document.getElementById('scoreX');
const scoreO = document.getElementById('scoreO');
const scoreDraw = document.getElementById('scoreDraw');

function init() {
    cells.forEach(cell => {
        cell.addEventListener('click', handleCellClick);
    });
    restartBtn.addEventListener('click', restartGame);
    resetScoreBtn.addEventListener('click', resetScore);
    updateScoreDisplay();
}

function handleCellClick(event) {
    const clickedCell = event.target;
    const clickedCellIndex = parseInt(clickedCell.getAttribute('data-index'));

    if (board[clickedCellIndex] !== '' || !gameActive) {
        return;
    }

    makeMove(clickedCell, clickedCellIndex);
}

function makeMove(cell, index) {
    board[index] = currentPlayer;
    cell.textContent = currentPlayer;
    
    if (currentPlayer === 'X') {
        cell.classList.add('text-blue-600');
    } else {
        cell.classList.add('text-red-600');
    }

    checkResult();
}
function checkResult() {
    let roundWon = false;
    let winningCombination = null;

    for (let i = 0; i < winningConditions.length; i++) {
        const [a, b, c] = winningConditions[i];
        if (board[a] === '' || board[b] === '' || board[c] === '') {
            continue;
        }
        if (board[a] === board[b] && board[b] === board[c]) {
            roundWon = true;
            winningCombination = [a, b, c];
            break;
        }
    }

    if (roundWon) {
        announceWinner(currentPlayer, winningCombination);
        gameActive = false;
        scores[currentPlayer]++;
        updateScoreDisplay();
        return;
    }

    if (!board.includes('')) {
        announceDraw();
        gameActive = false;
        scores.draw++;
        updateScoreDisplay();
        return;
    }

    currentPlayer = currentPlayer === 'X' ? 'O' : 'X';
    updateTurnInfo();
}

function announceWinner(player, combination) {
    gameStatus.textContent = ` Player ${player} Wins!`;
    gameStatus.classList.add('text-green-600');
    turnInfo.textContent = 'Game Over';
    
    combination.forEach(index => {
        cells[index].classList.add('bg-green-200');
    });
}

function announceDraw() {
    gameStatus.textContent = `  Draw!`;
    gameStatus.classList.add('text-yellow-600');
    turnInfo.textContent = 'Game Over';
}

function updateTurnInfo() {
    turnInfo.textContent = `Player ${currentPlayer}'s Turn`;
}

function updateScoreDisplay() {
    scoreX.textContent = scores.X;
    scoreO.textContent = scores.O;
    scoreDraw.textContent = scores.draw;
}

function restartGame() {
    board = ['', '', '', '', '', '', '', '', ''];
    currentPlayer = 'X';
    gameActive = true;
    gameStatus.textContent = '';
    gameStatus.classList.remove('text-green-600', 'text-yellow-600');
    updateTurnInfo();

    cells.forEach(cell => {
        cell.textContent = '';
        cell.classList.remove('text-blue-600', 'text-red-600', 'bg-green-200');
    });
}

function resetScore() {
    scores = {
        X: 0,
        O: 0,
        draw: 0
    };
    updateScoreDisplay();
    restartGame();
}

init();
