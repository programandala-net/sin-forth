\ lib/ahead.fs
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

require branch.fs       \ `branch`
require forward-mark.fs \ `>mark`

get-order get-current

compiler-definitions

: ahead \ Compilation: ( C: -- orig )
        \ Run-time:    ( -- )
  $0000 compiler{ branch >mark } ;

  \ doc{
  \
  \ ahead
  \   Compilation: ( C: -- orig )
  \   Run-time:    ( -- )

  \
  \ Compilation: Compile an unconditional `branch` and put the
  \ location _orig_ of its unresolved destination on the
  \ control-flow stack.
  \
  \ Run-time: Continue execution at the location specified by the
  \ resolution of _orig_.
  \
  \ }doc

set-current set-order
