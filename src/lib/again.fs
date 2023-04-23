\ lib/again.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require branch.fs \ `branch`

get-order get-current

compiler-definitions

compiler{ synonym again branch }

  \ doc{
  \
  \ again
  \   Compilation: ( C: dest -- )
  \   Run-time:    ( -- )

  \
  \ Compilation: Compile an unconditional `branch`
  \ to the backward reference _dest_, usually left by `begin`.
  \
  \ Run-time: Continue execution at the location specified by
  \ _dest_.
  \
  \ See also: `until`, `repeat`.
  \
  \ }doc

set-current set-order
