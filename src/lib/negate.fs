\ lib/negate.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require negate-hl.fs \ `negate-hl`
require pop-hl.fs    \ `pop-hl`
require push-hl.fs   \ `push-hl`

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
