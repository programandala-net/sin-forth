\ lib/defer.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1823+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

get-order get-current

compiler-definitions

: defer ( "name" -- )
  creator , 0 jp,
  does> ( dfa ) do-call ;

set-current set-order
