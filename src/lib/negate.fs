\ lib/negate.fs

\ This file is part of Sin Forth.

\ This file adds `negate` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require negate-hl.fs \ `negate-hl`
require pop-hl.fs    \ `pop-hl`
require push-hl.fs   \ `push-hl`

get-order get-current

target-definitions

: negate ( n1 -- n2 )

                      \                ; T  B
                      \                ; -- --
  pop-hl              \ call pop_hl    ; 17 03
  negate-hl_dea call, \ call negate_hl ; 17 03
  push-hl ;           \ jp push_hl     ; 10 03
                      \                ; -- --
                      \                ; 44 09

  \ doc{
  \
  \ negate ( n1 -- n2 )
  \
  \ Negate _n1_, giving its arithmetic inverse _n2_.
  \
  \ See also: `negate-hl`, `?negate`, `0=`, `inverse`, `dnegate`.
  \
  \ }doc

set-current set-order
