function ValidSudoku(board){
    const isValidSet = (arr) => {
        const set = new Set(arr);
        return set.size === 9 && !set.has(0);
      };
    
      // Перевірка всіх рядків
      for (let i = 0; i < 9; i++) {
        if (!isValidSet(board[i])) {
          return false;
        }
      }
    
      // Перевірка всіх стовпців
      for (let i = 0; i < 9; i++) {
        const column = [];
        for (let j = 0; j < 9; j++) {
          column.push(board[j][i]);
        }
        if (!isValidSet(column)) {
          return false;
        }
      }
    
      // Перевірка всіх блоків 3x3
      for (let i = 0; i < 9; i += 3) {
        for (let j = 0; j < 9; j += 3) {
          const block = [];
          for (let x = 0; x < 3; x++) {
            for (let y = 0; y < 3; y++) {
              block.push(board[i + x][j + y]);
            }
          }
          if (!isValidSet(block)) {
            return false;
          }
        }
      }
    
      return true;
}