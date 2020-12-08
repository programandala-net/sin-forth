\ lib/constant.fs

\ This file is part of Sin Forth.

\ This file adds `constant` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012081951.
\ See change log at the end of the file.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: constant ( "name" x -- )
  [ compiler-wordlist >order ] header [ previous ]
  z80dasm-blocks @ if dup s" _constant_data" new-z80dasm-cell-block then
  dup , t-!  2 memory> +!
  does> @ s" h ldp#, push-hl" evaluate ;

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>. Improve it with
\ `header`.
\
\ 2020-12-08: Create a z80dasm block.
