\ lib/defer.fs

\ This file is part of Sin Forth.

\ This file adds `defer` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012110334.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

compiler-definitions

: defer ( "name" -- )
  creator , 0 jp,
  does> ( dfa ) do-call ;

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-10: Start.
\
\ 2020-12-11: Finish.
