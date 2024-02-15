namespace tabuleiro
{
     class Tabuleiro
    {
        public int linhas {  get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return pecas [pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao p)
        {
            validarPosicao(p);
            return peca(p) != null;
        }

        public void ColocarPecas(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        public bool posicaoValida(Posicao p)
        {
            if (p.linha < 0 || p.linha >= linhas || p.coluna<0 || p.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao p)
        {
            if (!posicaoValida(p))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }
    }
}
